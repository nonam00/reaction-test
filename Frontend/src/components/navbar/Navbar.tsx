import React, { useState } from "react";

import { Result } from "../../core/resultType";
import ResultsComponent from "../results/ResultsComponent";

import classes from "../../styles/Navbar.module.css"
import menuIcon from "../../assets/images/menu.svg";

const Navbar: React.FC = (): React.ReactElement => {
  const [isOpen, setStatus] = useState<boolean>(false); // Is navigation bar opened
  const [results, setResults] = useState<Result[]>([]); // resents results from API
  const [loading, setLoading] = useState<boolean>(true); // loading status
  const [error, setError] = useState<Error | undefined>(undefined);

  const updateResults = async (address: string): Promise<void> => {
    await fetch(`${address}/api/get/all/${window.innerHeight/91 >> 0}`)
      .then(response => response.json())
      .then(
        (result: Result[]) => {
          setLoading(false);
          setResults(result);
        },
        (error: Error) => {
          setError(error)
          console.log(error.message);
        }
      )
  }

  const changeNavStatus = async (): Promise<void> => {
    setStatus(!isOpen);
  }

  const menuButtonClick = async (): Promise<void> => {
    if(!isOpen) {
      updateResults("https://localhost:7118");
    }
    else {
      setLoading(true);
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
        {<ResultsComponent results={results} error={error} loadingStatus={loading}/>}
      </div>
    </>
  );
}

export default Navbar;