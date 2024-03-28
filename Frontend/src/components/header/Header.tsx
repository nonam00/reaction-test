import React, { FC, ReactElement, useState } from "react";

import { Client, ResultListVm, ResultVm } from "../../api/api";
import ResultsComponent from "../results/ResultsComponent";

import classes from "../../styles/Navbar.module.css"
import menuIcon from "../../assets/images/menu.svg";

const apiClient = new Client('https://localhost:7118');

const Header: FC<{}> = (): ReactElement => {
  const [isOpen, setStatus] = useState<boolean>(false); // Is navigation bar opened
  const [results, setResults] = useState<ResultVm[] | undefined>(undefined); // resents results from API
  const [loading, setLoading] = useState<boolean>(true); // loading status
  const [error, setError] = useState<Error | undefined>(undefined);

  const getResults = async (): Promise<void> => {
    setLoading(true);
    const resultListVm: ResultListVm = await apiClient.getAll('1.0');
    setResults(resultListVm.results);
    setLoading(false);
  }

  const changeNavStatus = async (): Promise<void> => {
    setStatus(!isOpen);
  }

  const menuButtonClick = async (): Promise<void> => {
    if(!isOpen) {
      await getResults().catch((error) => {
        setError(error);
      });
    }
    else {
      setError(undefined);
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
        <ResultsComponent
          results={results}
          loadingStatus={loading}
          error={error}
        />
      </div>
    </>
  );
}

export default Header;