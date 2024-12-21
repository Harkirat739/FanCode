import { Routes } from '@angular/router';
import { HomeComponent } from './modules/components/Home/home/home.component';
import { LoginComponent } from './modules/components/Login/login/login.component';

export const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
];
