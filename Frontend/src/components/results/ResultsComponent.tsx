import React from "react";

import { ResultVm } from "../../api/api";

import classes from "../../styles/Results.module.css";

const ResultsComponent: React.FC<{results?: ResultVm[], error?: Error, loadingStatus: boolean}>
    = ({results, error, loadingStatus}): React.ReactElement => {  
  if(error !== undefined) {
    return (
      <>
        <p>Error on loading data</p>
        <p>{error.message}</p>
      </>
    );
  }
  if(loadingStatus) {
    return <p>Loading</p>;
  }
  return (
    <ul className={classes.results_list}>
      {results?.map((item, index) => (
        <li key={index} className={classes.result_element}>
          <div>
            <p>Date: {new Date(item.testDate).toLocaleString()}</p>
            <p>Reaction time: {item.reactionTime}ms</p>
          </div>
        </li>
      ))}
    </ul>
  );
}

export default ResultsComponent;