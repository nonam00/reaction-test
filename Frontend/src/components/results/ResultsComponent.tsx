import React, { useState, useEffect } from "react";

import { Result } from "./resultType";
import classes from "../../styles/Results.module.css";

const ResultsComponent: React.FC = (): React.ReactElement => {
  const [results, setResults] = useState<Array<Result>>([]);

  useEffect(() => {
    fetch("https://localhost:7118/api/get/all/10")
      .then(response => response.json())
      .then(
        (result) => { setResults(result); },
        (error) => { console.log(error); }
      )
  }, [])

  return (
    <ul className={classes.results_list}>
      {results.map(item => (
        <li key={item.id} className={classes.result_element}>
          <div>
            <p>Date: {new Date(item.testDate).toDateString()}</p>
            <p>Reaction time: {item.reactionTime}ms</p>
          </div>
        </li>
      ))}
    </ul>
  );
}

export default ResultsComponent;