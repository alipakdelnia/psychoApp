import { Routes } from '@angular/router';
import { UsersComponent } from './features/users/users.component';
import { EditUserComponent } from './features/edit-user/edit-user.component';

export const routes: Routes = [
    {  path: 'userlist', component: UsersComponent},
    { path: 'edit-user/:id', component: EditUserComponent },
    { path: '**', redirectTo: '', pathMatch: 'full' }
];
