import React, {useEffect, useState} from "react";

import { Result } from "./result-type";

const ResultsComponent: React.FC = (): React.ReactElement => {
  const [error, setError] = useState<Error>();
  const [isLoaded, setIsLoaded] = useState(false);
  const [items, setItems] = useState<Array<Result>>([]);

  useEffect(() => {
    fetch("https://localhost:7118/api/get")
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
    return <div>loading</div>;
  }
  else {
    return (
      <ul>
        {items.map(item => (
          <li key={item.id}>
            {item.reactionTime}
          </li>
        ))}
      </ul>
    );
  }
}

export default ResultsComponent;