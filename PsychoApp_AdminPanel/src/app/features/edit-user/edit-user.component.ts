import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router, RouterModule } from '@angular/router';
import { EditUserService } from './edit-user.service';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';



@Component({
  selector: 'app-edit-user',
  standalone: true,
  imports: [MatFormFieldModule,ReactiveFormsModule,RouterModule],
  templateUrl: './edit-user.component.html',
  styleUrl: './edit-user.component.css'
})


export class EditUserComponent implements OnInit {
  userId!: number;

  editForm = new FormGroup({
    id: new FormControl(null),
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    username: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    passwordHash: new FormControl('', [Validators.required]),
  })

  constructor(
    private editUserService: EditUserService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    // دریافت شناسه کاربر از پارامترهای URL
    this.userId = +this.route.snapshot.paramMap.get('id')!;
  
    // دریافت اطلاعات کاربر و پر کردن فرم
    this.editUserService.getUserById(this.userId).subscribe(user => {
      if (user) {
        this.editForm.patchValue({
          id: user.id || null,
          firstName: user.firstName || '',
          lastName: user.lastName || '',
          username: user.username || '',
          email: user.email || '',
          passwordHash: user.passwordHash || '1'
        });
      }
    });
  }
  

  // ارسال اطلاعات ویرایش شده
  onSubmit(): void {

    // if (this.editForm.valid) {
      this.editUserService.updateUser(this.editForm.value).subscribe((sub)=>{
        console.log(sub);
        this.router.navigate(['/userlist']);
     } );
    // }else{
      // alert("لطفا تمامی فیلدها را پر کنید");
      console.log(this.editForm.value)
    // }
    
  }
}