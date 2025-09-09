import { CanActivateFn } from '@angular/router';

export const loginGuardGuard: CanActivateFn = (route, state) => {
  const userLogin = localStorage.getItem('currentUserDetails');
  return userLogin ? true : false;
};
