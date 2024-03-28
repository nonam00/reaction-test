import React, { FC, ReactElement, useEffect } from 'react'
import { useNavigate } from 'react-router-dom';
import Header from '../header/Header';
import Button from '../button/Button';
import Footer from '../footer/Footer';

import userManager from '../../auth/user-service';

const GameComponent: FC<{}> = (): ReactElement => {
  const navigate = useNavigate();

  // check for completed authenentication in the app 
  useEffect(() => {
    const checkAuthentication = async(): Promise<void> => {
      const user =  await userManager.getUser();
      const isAuthenticated = user !== null;
      // redirection to the page for unauthorized users
      if(!isAuthenticated) {
        navigate('/unauthorized');
      }
    };
    checkAuthentication();
  }, [navigate]);
  
  return (
    <>
      <Header />
      <Button />
      <Footer />
    </>
  );
}

export default GameComponent;
