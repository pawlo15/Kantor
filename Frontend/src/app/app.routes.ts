import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { NgModule } from '@angular/core';
import { PanelComponent } from './panel/panel.component';
import { AuthGuard } from '../services/auth/auth.guard';

export const routes: Routes = [
    {
        path: '',
        component: AuthComponent
    },
    {
        path: 'panel',
        component: PanelComponent,
        //canActivate: [AuthGuard]
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
