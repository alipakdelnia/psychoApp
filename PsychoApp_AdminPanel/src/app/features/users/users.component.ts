import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { UsersService } from './users.service';
import { RouterModule } from '@angular/router';
import { TranslateDirective, TranslatePipe, TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [NgFor,RouterModule,TranslatePipe],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent implements OnInit{
  users: any[] = [];

  constructor(private usersService: UsersService,private translate: TranslateService) {
    
  }

  ngOnInit(): void {
    this.usersService.getUsers().subscribe(
      data => this.users = data
    );
  }


}
