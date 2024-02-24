import { useState } from "react";

export enum ButtonStatus {
  IDLE,
  WAITING,
  CLICKABLE,
  RESULT
}

// Define the return type of the ButtonState function
type ButtonStateReturnType = {
  status: ButtonStatus;
  result: string;
  start: () => void;
  clickOnTime: () => void;
  lose: () => void;
  reset: () => void;
};



const ButtonState = (): ButtonStateReturnType => {
  const [status, setStatus] = useState<ButtonStatus>(ButtonStatus.IDLE); //defines the current button
  const [time, setTime] = useState<number>(0); //time at which the button appeared
  const [result, setResult] = useState<string>("");//
  const [delay, rememberDelay] = useState<NodeJS.Timeout>();

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
    setResult(`${Date.now() - time} ms`); //determines the time elapsed from appearance to pressing
    setStatus(ButtonStatus.RESULT);
  };

  // Function to handle the action when the button is clicked too early
  const lose = (): void => {
    clearTimeout(delay);
    setResult('too early');
    setStatus(ButtonStatus.RESULT); 
  };

  // Function to reset the button state
  const reset = (): void => {
    setStatus(ButtonStatus.IDLE);
    setResult("");
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