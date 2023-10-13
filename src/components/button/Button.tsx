import React, {useState} from "react";

import classes from "./Button.module.css";

const StartButton = () => {
  const [randomDelay, setDelay] = useState();
  const [lose, setLose] = useState(0);
  const [status, setStatus] = useState(0);
  var [time, setTime] = useState();
  const [result, setResult] = useState(new Date());

  const Start = () => {
    setDelay(Math.floor(Math.random() * 2000) + 1000);
    setStatus(1);
  }

  const Increment = () => {
    console.log(lose);
    if(!lose)
    {
      setStatus(status+1);
      setTime(Date.now());
    }
  };

  const ClickOnTime = () => {
    setResult(Date.now() - time);
    setStatus(3);
  }
  const Lose = () => {
    setResult('too early');
    setStatus(3);
    setLose(1);
  }

  const Reset = () => {
    setStatus(0);
  }

  var ret = {
    0: <button className={classes.start} onClick={Start}>press to start</button>,
    1: <button className={classes.wait}>wait until the button turns green</button>,
    2: <button className={classes.click} onClick={ClickOnTime}>click</button>,
    3: <button className={classes.result} onClick={Reset}>{result} ms<p>reset</p></button>
  }

  const returnButt = () => {
    if(status===1) {
      setTimeout(Increment, randomDelay);
    }
    return (ret[status]);
  }

  return (
    <div className={classes.butt}>
      {returnButt()}
    </div>
  );
}

export default StartButton;