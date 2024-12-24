import { Component } from '@angular/core';
import { EditUserComponent } from '../../edit-user/edit-user.component';
import { UsersService } from '../users.service';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { RouterModule,Router } from '@angular/router';
import { TranslatePipe } from '@ngx-translate/core';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-add-new-user',
  standalone: true,
  imports: [MatFormFieldModule,ReactiveFormsModule,RouterModule,TranslatePipe],
  templateUrl: './add-new-user.component.html',
  styleUrl: './add-new-user.component.css'
})
export class AddNewUserComponent {
  
   editForm = new FormGroup({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      username: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      passwordHash: new FormControl('', [Validators.required]),
    })

constructor(private usersService: UsersService,private router : Router){}

onSubmit(): void {
  this.usersService.addUser(this.editForm.value).subscribe((sub)=>{
  console.log(sub);
  this.router.navigate(['/userlist']);
} );
// }else{
// alert("لطفا تمامی فیلدها را پر کنید");
console.log(this.editForm.value)
}


}
