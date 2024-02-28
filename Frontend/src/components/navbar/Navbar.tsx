import React, { useState } from "react";

import { Result } from "../../core/resultType";
import ResultsComponent from "../results/ResultsComponent";

import classes from "../../styles/Navbar.module.css"
import menuIcon from "../../assets/images/menu.svg";

const Navbar: React.FC = (): React.ReactElement => {
  const [isOpen, setStatus] = useState<boolean>(false);
  const [results, setResults] = useState<Result[]>([]);

  const updateResults = (): void => {
    fetch(`https://localhost:7118/api/get/all/${window.innerHeight/91 >> 0}`)
      .then(response => response.json())
      .then(
        (result) => { setResults(result); },
        (error) => { console.log(error); }
      )
  }

  const changeNavStatus = (): void => {
    setStatus(!isOpen);
  }

  const menuButtonClick = (): void => {
    if(!isOpen) {
      updateResults();
    }
    changeNavStatus();
  }

  return (
    <>
      <button
        className={ isOpen? [classes.close_button, classes.close_button_active].join(' ') : classes.close_button }
        onClick={changeNavStatus} 
      />
      <header className={classes.app_header}>
        <h1>Reaction App</h1>
        <img
          className={classes.menu_button}
          src={menuIcon}
          onClick={menuButtonClick}
          alt=""
        />
      </header>
        <div className={ isOpen? [classes.results, classes.results_active].join(' ') : classes.results }>
          <ResultsComponent results={results}/>
        </div>
    </>
  );
}

export default Navbar;