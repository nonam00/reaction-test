import React, { FC, ReactElement, useEffect } from 'react'
import { useNavigate } from 'react-router-dom';

import userManager, { signinRedirect } from '../../auth/user-service';
import Footer from '../footer/Footer';
import classes from '../../styles/UnauthorizedPage.module.css';

const UnauthorizedPage: FC<{}> = (): ReactElement => {
  // check for completed authenentication in the app 
  const navigate = useNavigate();
  useEffect(() => {
    const checkAuthentication = async(): Promise<void> => {
      const user =  await userManager.getUser();
      const isAuthenticated = user !== null;
      // redirection to the page for authorized users
      if(isAuthenticated) {
        navigate('/');
      }
    };
    checkAuthentication();
  }, [navigate]);

  return (
    <>
      <header className={classes.app_header}>
        <h1>Reaction App</h1>
      </header>
      <div className={classes.page}>
        <p>Unauthorized</p>
        <p>Press the button to log in</p>
        <button onClick={() =>  signinRedirect()}>Login</button>
      </div>
      <Footer />
    </>
  )
}

export default UnauthorizedPage;