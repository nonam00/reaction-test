import React, {ReactElement, useState} from "react";
import classes from "../../styles/Button.module.css";

const Button : React.FC = () : ReactElement => {
  const [timeout, rememberDelay] = useState<NodeJS.Timeout>();
  const [randomDelay, setDelay] = useState<number>(); //delay delay before button appears
  const [status, setStatus] = useState<number>(0); //defines the current button
  const [time, setTime] = useState<number>(); //time at which the button appeared
  const [result, setResult] = useState<string>();//

  const Start = (): void => {
    setDelay(Math.floor(Math.random() * 2000) + 1000); //defines the delay before the button appears
    const delay: NodeJS.Timeout = setTimeout(MainButtonApear, randomDelay);
    rememberDelay(delay);
    setStatus(1); //switch to waiting mode for the button to appear
  }

  const MainButtonApear = (): void => { //button appears after a delay
    setStatus(status+2);
    setTime(Date.now()); //time at which the button appeared
  };

  const ClickOnTime = (): void => { //after pressing the button
    if(time === undefined)
      return;
    setResult((Date.now() - time).toString()+" ms"); //determines the time elapsed from appearance to pressing
    setStatus(3); //switch to results summary mode
  }

  const Lose = (): void => {
    clearTimeout(timeout);
    setResult('too early');
    setStatus(3);
  }

  const Reset = (): void => setStatus(0);

  const buttons: Record<number, React.JSX.Element> = {
    0: <button className={classes.start} onClick={Start}>press to start</button>, //start button
    1: <button className={classes.wait} onClick={Lose}>wait until the button turns green</button>, //waiting mode
    2: <button className={classes.click} onClick={ClickOnTime}>click</button>, //main button
    3: <button className={classes.result} onClick={Reset}>{result}<p>reset</p></button> //results summary mode + reset button
  };

  const returnButt = (): React.JSX.Element => {
    return (buttons[status]);
  }

  return (
    <div className={classes.butt}>
      {returnButt()}
    </div>
  );
}

export default Button;