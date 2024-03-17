import { useState } from "react";

export enum ButtonStatus {
  IDLE,
  WAITING,
  CLICKABLE,
  RESULT
}

// Define the return type of the ButtonState function
type ButtonStateReturnType = {
  status: ButtonStatus
  result: number
  start: () => void
  clickOnTime: () => void
  lose: () => void
  reset: () => void
};

const ButtonState = (): ButtonStateReturnType => {
  const [status, setStatus] = useState<ButtonStatus>(ButtonStatus.IDLE); //defines the current button
  const [time, setTime] = useState<number>(0); //time at which the button appeared
  const [result, setResult] = useState<number>(0);//
  const [delay, rememberDelay] = useState<NodeJS.Timeout>();

  const saveResultRequest = async (result: number): Promise<void> => {
    const resultData = {
      testDate: new Date(),
      reactionTime: result
    };

    const requestOptions: RequestInit = {
      method: "POST",
      mode: "cors",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(resultData)
    };
    
    await fetch("https://localhost:7118/api/add", requestOptions)
      .then(response => response.json())
      .then(
        () => {},
        (error: Error) => {console.log(error.message)}
      );
  }

  // Function to initiate the waiting state with a random delay
  const start = (): void => {
    setStatus(ButtonStatus.WAITING);

    const randomDelay: number = Math.floor(Math.random() * 2000) + 1000;
    const delay: NodeJS.Timeout = setTimeout(() => {
      setStatus(ButtonStatus.CLICKABLE);
      setTime(Date.now());
    }, randomDelay);

    rememberDelay(delay);
  };

  // Function to handle the action when the button is clicked at the right time
  const clickOnTime = (): void => {
    if(time === undefined) return;
    const resultTime = Date.now() - time;

    setResult(resultTime); //determines the time elapsed from appearance to pressing

    saveResultRequest(resultTime);

    setStatus(ButtonStatus.RESULT);
  };

  // Function to handle the action when the button is clicked too early
  const lose = (): void => {
    clearTimeout(delay);
    setStatus(ButtonStatus.RESULT); 
  };
  
  // Function to reset the button state
  const reset = (): void => {
    setStatus(ButtonStatus.IDLE);
    setResult(0);
  };

  return { 
    status,
    result,
    start,
    clickOnTime,
    lose,
    reset
  };
};

export default ButtonState;