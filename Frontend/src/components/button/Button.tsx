import React, {ReactElement} from "react";
import ButtonState, {ButtonStatus} from "./buttonState";
import classes from "../../styles/Button.module.css";

const Button: React.FC = (): ReactElement => {
  const {status, result, start, clickOnTime, lose, reset} = ButtonState();

  // Define buttons based on the status
  const buttons: Record<ButtonStatus, React.JSX.Element> = {
    //start button
    [ButtonStatus.IDLE]:
      <button
        className={classes.start}
        onClick={start}
      >
          press to start
      </button>,

    //waiting mode
    [ButtonStatus.WAITING]:
      <button
        className={classes.wait}
        onClick={lose}
      >
          wait until the button turns green
      </button>, 

    //main button
    [ButtonStatus.CLICKABLE]:
      <button
        className={classes.click}
        onClick={clickOnTime}
      >
          click
      </button>, 

    //results summary mode + reset button
    [ButtonStatus.RESULT]:
      <button
        className={classes.result}
        onClick={reset}
      >
          {result}
          <p>reset</p>
      </button> 
  };

  return (
    <div className={classes.button}>
      {buttons[status]}
    </div>
  );
}

export default Button;