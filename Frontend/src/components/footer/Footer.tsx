import React, { ReactElement } from "react";
import classes from "../../styles/Footer.module.css";

import github from "../../assets/images/github-mark-white.svg";
import tg from "../../assets/images/tg-logo.svg";

const Footer: React.FC = (): ReactElement => {
  return (
    <footer className={classes.footer}>
      <div>
        <a href="https://github.com/nonam00/" target="_blank" rel="noreferrer">
          <img src={github} alt=""/>
        </a>
        <a href="https://t.me/NoNam0000" target="_blank" rel="noreferrer">
          <img src={tg} alt="" />
        </a>
      </div>
      <p className={classes.copyrights}>©2024 Raisky</p>
    </footer>
  );
};

export default Footer;