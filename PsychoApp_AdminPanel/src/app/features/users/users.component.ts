import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { UsersService } from './users.service';
import { Router, RouterModule } from '@angular/router';
import { TranslateDirective, TranslatePipe, TranslateService } from '@ngx-translate/core';


@Component({
  selector: 'app-users',
  standalone: true,
  imports: [NgFor, TranslatePipe, RouterModule],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent implements OnInit {
  users: any[] = [];
  allSelected: boolean = false; // وضعیت چک‌باکس هدر

  constructor(private usersService: UsersService, private translate: TranslateService,private router: Router) {

  }

  ngOnInit(): void {
    this.usersService.getUsers().subscribe(
      data => this.users = data
    );
  }

  addNewUser() {
    this.router.navigate(['add-new-user'])
  }

  deleteUser(): void {
    console.log('Delete button clicked!');
    // عملکرد حذف کاربر (یا هر عملکرد مورد نظر) را اینجا اضافه کنید
  }
  
  

}
