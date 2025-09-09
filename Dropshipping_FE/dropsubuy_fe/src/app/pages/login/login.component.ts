import { Component, ChangeDetectionStrategy, OnInit } from '@angular/core';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { FormControl, FormGroup, FormGroupDirective, FormsModule, NgForm, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ErrorStateMatcher } from '@angular/material/core';
import {MatToolbarModule} from '@angular/material/toolbar';
import { AuthServiceService } from '../../services/auth-service.service';
import { Router } from '@angular/router';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}


@Component({
  selector: 'dbuy-login',
  standalone: true,
  imports: [MatSelectModule, MatInputModule, MatFormFieldModule, CommonModule, ReactiveFormsModule, FormsModule, MatToolbarModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
  public loginDetails: FormGroup = new FormGroup({});
  public matcher = new MyErrorStateMatcher();
  public showError: boolean = false;
  constructor(private authService: AuthServiceService, private router: Router) {

  }

  ngOnInit() {
    this.loginDetails = new FormGroup({
      email: new FormControl('',[Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)])
    });
  }
  
  protected onClickLogin(): void {
    this.showError = true;
    if(this.loginDetails.valid) {
      const {email, password} = this.loginDetails.value;
      this.authService.login(email, password).subscribe({
        next: (response) => {
          localStorage.setItem('currentUserDetails', JSON.stringify(response));
          this.showError = false;
          this.router.navigate(['/home']);
        },
        error: (error) => {
          console.log("here?")
        }
      });
    }
  }
}
