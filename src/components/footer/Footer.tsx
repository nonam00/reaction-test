import React from "react";
import classes from "./Footer.module.css";

import github from "./github-mark-white.svg";
import tg from "./tg-logo.svg";

const Footer = () => {
  return (
    <footer className={classes.foo}>
      <div>
        <a href="https://github.com/nonam00/" target="_blank">
          <img src={github} alt=""/>
        </a>
        <a href="https://t.me/NoNam0000" target="_blank">
          <img src={tg} alt="" />
        </a>
      </div>
      <p className={classes.copyrights}>©2023 Raisky</p>
    </footer>
  );
};

export default Footer;