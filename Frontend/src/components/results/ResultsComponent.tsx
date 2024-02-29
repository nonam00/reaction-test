import React from "react";

import { Result } from "../../core/resultType";
import classes from "../../styles/Results.module.css";

const ResultsComponent: React.FC<{results: Result[]}> = ({results}): React.ReactElement => {  
  return (
    <ul className={classes.results_list}>
      {results.map(item => (
        <li key={item.id} className={classes.result_element}>
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