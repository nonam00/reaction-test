export const setAuthHeader = (token: string | null | undefined): void => {
  localStorage.setItem('token', token ? token : '');
}