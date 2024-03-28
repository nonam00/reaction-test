import React, { FC, ReactElement, useEffect, useState } from 'react'

import Header from '../header/Header';
import Button from '../button/Button';
import Footer from '../footer/Footer';
import UnauthorizedPage from './UnauthorizedPage';

import userManager from '../../auth/user-service';

const GameComponent: FC<{}> = (): ReactElement => {
  const [isAuth, setAuth] = useState<boolean>(false);

  const checkForUserAsync = async(): Promise<void> => {
    const user =  await userManager.getUser();
    console.log(user);
    setAuth(user !== null);
  }

  useEffect(() => {
    checkForUserAsync();
  }, [])

  if(!isAuth) {
    return (
      <UnauthorizedPage />
    );
  }

  return (
    <>
      <Header />
      <Button />
      <Footer />
    </>
  );
}

export default GameComponent;
