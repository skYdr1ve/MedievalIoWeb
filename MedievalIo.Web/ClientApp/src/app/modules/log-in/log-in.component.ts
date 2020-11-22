import { Component, NgModule, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from "../../shared/services/auth.service";
import { LoginModel } from "../../models/login.model";

@Component({
  selector: 'log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})

export class LogInComponent {
  isModal = false;
  defaultFont: string;
  model: LoginModel;
  returnUrl: string;

  @Output() closeEmitter = new EventEmitter<any>();

  constructor(private router: Router,
    private authService: AuthService,
    private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.model = this.getDefaultModel();

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  onSubmit(model: NgForm): void {
    this.authService.logIn(model.value,
      result => {
        if (result) {
          this.close();
          this.router.navigate([this.returnUrl]);
          return;
        }
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

}

@NgModule({
  declarations: [LogInComponent],
  exports: [LogInComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule
  ]
})
export class LogInModule { }
