import React, {useEffect, useState} from "react";

import { Result } from "./resultType";
import classes from "../../styles/Results.module.css";

const ResultsComponent: React.FC = (): React.ReactElement => {
  const [error, setError] = useState<Error>();
  const [isLoaded, setIsLoaded] = useState(false);
  const [items, setItems] = useState<Array<Result>>([]);

  useEffect(() => {
    fetch("https://localhost:7118/api/get/10")
      .then(response => response.json())
      .then(
        (result) => {
          setIsLoaded(true);
          setItems(result);
        },
        (error) => {
          setIsLoaded(true);
          setError(error);
        }
      )
  }, [])

  if(error) {
    return <div>{error.message}</div>;
  }
  else if(!isLoaded)
  {
    return <div>Loading</div>;
  }
  else {
    return (
      <ul className={classes.results_list}>
        {items.map(item => (
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
}

export default ResultsComponent;