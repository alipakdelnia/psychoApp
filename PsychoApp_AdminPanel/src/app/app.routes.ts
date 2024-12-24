import { Routes } from '@angular/router';
import { UsersComponent } from './features/users/users.component';
import { EditUserComponent } from './features/edit-user/edit-user.component';
import { AddNewUserComponent } from './features/users/add-new-user/add-new-user.component';

export const routes: Routes = [
    {  path: 'userlist', component: UsersComponent},
    { path: 'edit-user/:id', component: EditUserComponent },
    { path: 'add-new-user', component: AddNewUserComponent },
    { path: '**', redirectTo: 'userlist', pathMatch: 'full' }
];
