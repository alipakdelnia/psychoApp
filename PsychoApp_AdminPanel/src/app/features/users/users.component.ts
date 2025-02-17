import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { UsersService } from './users.service';
import { Router, RouterModule } from '@angular/router';
import { TranslateDirective, TranslatePipe, TranslateService } from '@ngx-translate/core';
import { DeleteDialogComponent } from '../../shared/delete-dialog/delete-dialog.component';


@Component({
  selector: 'app-users',
  standalone: true,
  imports: [NgFor, TranslatePipe, RouterModule,DeleteDialogComponent],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent {
  users: any[] = [];
  allSelected: boolean = false; // وضعیت چک‌باکس هدر
  isDialogVisible: boolean = false;
  selectedUserId: number | null = null;

  constructor(private usersService: UsersService, private translate: TranslateService,private router: Router) {

  }

  ngAfterViewInit(): void {
    this.refreshPage();
  }

  addNewUser() {
    this.router.navigate(['add-new-user'])
  }

  refreshPage(): void {
    this.usersService.getUsers().subscribe(
      data => this.users = data
    );
    }
  
   openDialog(userId: number) {
    this.selectedUserId = userId;
    this.isDialogVisible = true;
  }

  closeDialog() {
    this.isDialogVisible = false;
    this.selectedUserId = null;
  }

  deleteUser() {
    if (this.selectedUserId !== null) {
     this.usersService.deleteUser(this.selectedUserId).subscribe((sub) => {
       console.log(sub);
       this.refreshPage();
     })
      this.closeDialog();
    }
  }

}
