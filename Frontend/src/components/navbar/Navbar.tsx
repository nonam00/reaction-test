import React, { useState } from "react";

import ResultsComponent from "../results/ResultsComponent";

import classes from "../../styles/Navbar.module.css"

const Navbar: React.FC = (): React.ReactElement => {
  const [navStatus, setNavStatus] = useState<boolean>(false);

  const changeNavStatus = (): void => {
    setNavStatus(!navStatus);
  }

  return (
    <>
      <header className={classes.app_header}>
        <h1>Reaction App</h1>
        <button
          className={classes.menu_button}
          onClick={changeNavStatus}
        >
        </button>
        <button
          className={ navStatus? [classes.close_button, classes.close_button_active].join(' ') : classes.close_button }
          onClick={changeNavStatus} 
        >
        </button>
      </header>
        <div className={ navStatus? [classes.results, classes.results_active].join(' ') : classes.results }>
          <ResultsComponent/>
        </div>
    </>
  );
}

export default Navbar;