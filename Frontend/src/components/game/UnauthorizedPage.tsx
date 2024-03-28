import React, { FC, ReactElement } from 'react'

import { signinRedirect } from '../../auth/user-service';

import Footer from '../footer/Footer';

import classes from '../../styles/UnauthorizedPage.module.css';

const UnauthorizedPage: FC<{}> = (): ReactElement => {
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