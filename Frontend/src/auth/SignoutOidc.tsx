import React, { FC, ReactElement, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { signoutRedirectCallback } from "./user-service";

const SignoutOidc: FC<{}> = (): ReactElement => {
  const navigate = useNavigate();
  useEffect(() => {
    const signoutAsync = async () => {
      await signoutRedirectCallback();
      navigate('/');
    };
    signoutAsync();
  }, [navigate]);
  return <>Redirecting...</>
};

export default SignoutOidc;