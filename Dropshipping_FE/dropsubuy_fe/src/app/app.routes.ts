import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { ErrorpageComponent } from './pages/errorpage/errorpage.component';
import { loginGuardGuard } from './guards/login-guard.guard';

export const routes: Routes = [
    {path: 'login', component: LoginComponent},
    {path: 'home', component: HomepageComponent, canActivate: [loginGuardGuard]},
    {path: '', redirectTo: 'login', pathMatch: 'full'},
    {path: '**', component: ErrorpageComponent},
];
