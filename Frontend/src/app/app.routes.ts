import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { NgModule } from '@angular/core';
import { PanelComponent } from './panel/panel.component';
import { AuthGuard } from '../services/auth/auth.guard';
import { RegistrationComponent } from './registration/registration.component';

export const routes: Routes = [
    {
        path: '',
        component: AuthComponent
    },
    {
        path: 'panel',
        component: PanelComponent,
        //canActivate: [AuthGuard]
    },
    {
        path: 'registration',
        component: RegistrationComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
