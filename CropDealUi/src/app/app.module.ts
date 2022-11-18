import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import{BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { LoginComponent } from './login/login.component';
import { AppHomeComponent } from './app-home/app-home.component';
import { HttpClientModule,HTTP_INTERCEPTORS } from  '@angular/common/http';
import { FormsModule } from '@angular/forms';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import { SignupComponent } from './signup/signup.component';
import { ViewCropsComponent } from './view-crops/view-crops.component';
import { TokenInterceptorService } from './_Services/token-interceptor.service';
import { CropOnSaleComponent } from './crop-on-sale/crop-on-sale.component';
import { ViewYourCropsComponent } from './view-your-crops/view-your-crops.component';
import { UpdateUserComponent } from './update-user/update-user.component';
import { FarmerLandingPageComponent } from './farmer-landing-page/farmer-landing-page.component';
import { DealerLandingPageComponent } from './dealer-landing-page/dealer-landing-page.component';
import { AdminLandingPageComponent } from './admin-landing-page/admin-landing-page.component';
import { InvoiceComponent } from './invoice/invoice.component';
import { FarmerInvoiceComponent } from './farmer-invoice/farmer-invoice.component';
import { ReportGenrationComponent } from './report-genration/report-genration.component';
import { ChangeUserStatusComponent } from './change-user-status/change-user-status.component';
import { ProfileComponent } from './profile/profile.component';
import { FeaturesComponent } from './features/features.component';
import { PaymentSuccessfullComponent } from './payment-successfull/payment-successfull.component';
import { AuthGuard } from './auth.guard';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    LoginComponent,
    AppHomeComponent,
    SignupComponent,
    ViewCropsComponent,
    CropOnSaleComponent,
    ViewYourCropsComponent,
    UpdateUserComponent,
    FarmerLandingPageComponent,
    DealerLandingPageComponent,
    AdminLandingPageComponent,
    InvoiceComponent,
    FarmerInvoiceComponent,
    ReportGenrationComponent,
    ChangeUserStatusComponent,
    ProfileComponent,
    FeaturesComponent,
    PaymentSuccessfullComponent,
    PagenotfoundComponent,
    UnauthorizedComponent,
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    NgbModule,
    ReactiveFormsModule
  ],
  providers: [{provide:HTTP_INTERCEPTORS,useClass:TokenInterceptorService,multi:true},AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
