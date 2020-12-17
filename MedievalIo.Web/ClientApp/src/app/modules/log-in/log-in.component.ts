import { Component, NgModule, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, NgForm, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from "../../shared/services/auth.service";
import { LoginModel } from "../../models/login.model";
import { RegisterModel } from "../../models/register.model";
import { MaterialModule } from "../../material-module";
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css'],
})

export class LogInComponent {
  isModal = false;
  defaultFont: string;
  model: LoginModel;
  registerModel: RegisterModel;
  returnUrl: string;
  isRegister = false;
  registerForm: FormGroup;
  @Output() closeEmitter = new EventEmitter<any>();

  constructor(private router: Router,
    private authService: AuthService,
    private route: ActivatedRoute,
    private toastr: ToastrService) {
  }

  ngOnInit() {
    this.model = this.getDefaultModel();
    this.registerModel = {
      name: '',
      email: '',
      password: '',
      confirmedPassword: ''
    }
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.registerForm = new FormGroup({
      'name': new FormControl(this.registerModel.name, Validators.required),
      'email': new FormControl(this.registerModel.email, Validators.required),
      'password': new FormControl(this.registerModel.password, [Validators.required, Validators.pattern("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$")]),
      'confirmedPassword': new FormControl(this.registerModel.confirmedPassword, Validators.required),
    });
  }

  get password() { return this.registerForm.get('password') };
  get confirmedPassword() { return this.registerForm.get('confirmedPassword') };

  onSubmitForm() {
    if (this.registerForm.invalid) {
      return;
    }
    this.authService.register(this.registerForm.value as RegisterModel).subscribe( result => {
      if (result) {
        this.isRegister = false;
        this.toastr.success('Success');
        return;
      }

      this.toastr.error('Error');
    });
  }

  onSubmit(model: NgForm): void {
    this.authService.logIn(model.value,
      result => {
        console.log(result);
        if (result) {
          this.close();
          this.toastr.success('Success');
          this.router.navigate([this.returnUrl]);
          return;
        }

        this.toastr.error('Error');
        return 
      });
  }

  close() {
    this.closeEmitter.emit();
  }

  onClickLink(url: string) {
    this.router.navigateByUrl(url);
    this.close();
  }

  getDefaultModel() {
    return {
      userEmail: '',
      password: ''
    } as LoginModel;
  }

  changeForm() {
    this.isRegister = !this.isRegister;
  }
}

@NgModule({
  declarations: [LogInComponent],
  exports: [LogInComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    MaterialModule
  ]
})
export class LogInModule { }
