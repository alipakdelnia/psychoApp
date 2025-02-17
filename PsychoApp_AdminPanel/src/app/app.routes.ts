import { Routes } from '@angular/router';
import { UsersComponent } from './features/users/users.component';
import { EditUserComponent } from './features/edit-user/edit-user.component';
import { AddNewUserComponent } from './features/users/add-new-user/add-new-user.component';
import { ChatScreenComponent } from './features/chat-screen/chat-screen.component';

export const routes: Routes = [
    {  path: 'userlist', component: UsersComponent},
    { path: 'edit-user/:id', component: EditUserComponent },
    { path: 'add-new-user', component: AddNewUserComponent },
    {path : 'chat-screen', component: ChatScreenComponent},
    { path: '**', redirectTo: 'chat-screen', pathMatch: 'full' }
];
