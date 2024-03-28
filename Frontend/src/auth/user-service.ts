import { UserManager, UserManagerSettings } from "oidc-client";
import { setAuthHeader } from "./auth-headers";

const userManagerSetting: UserManagerSettings = {
  client_id: 'reaction-test-web-app',
  redirect_uri: 'http://localhost:3000/signin-oidc',
  response_type: 'code',
  scope: 'openid profile ResultsWebAPI',
  authority: 'https://localhost:7076/',
  post_logout_redirect_uri: 'http://localhost:3000/singout-oidc',
}

const userManager = new UserManager(userManagerSetting);

export const loadUser = async () => {
  const user = await userManager.getUser();
  console.log('User: ', user);
  const token = user?.access_token;
  setAuthHeader(token);
}

export const signinRedirect = () => userManager.signinRedirect();

export const signinRedirectCallback = () => {
  userManager.signinRedirectCallback()
  .catch((err) => {});
}

export const signoutRedirect = (args?: any) => {
  userManager.clearStaleState();
  userManager.removeUser();
  return userManager.signoutRedirect(args);
}

export const signoutRedirectCallback = () => {
  userManager.clearStaleState();
  userManager.removeUser();
  return userManager.signoutRedirectCallback(); 
}

export default userManager;