import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminLandingPageComponent } from './admin-landing-page/admin-landing-page.component';
import { AppHomeComponent } from './app-home/app-home.component';
import { AuthGuard } from './auth.guard';
import { ChangeUserStatusComponent } from './change-user-status/change-user-status.component';
import { CropOnSaleComponent } from './crop-on-sale/crop-on-sale.component';
import { DealerLandingPageComponent } from './dealer-landing-page/dealer-landing-page.component';
import { FarmerInvoiceComponent } from './farmer-invoice/farmer-invoice.component';
import { FarmerLandingPageComponent } from './farmer-landing-page/farmer-landing-page.component';
import { FeaturesComponent } from './features/features.component';
import { InvoiceComponent } from './invoice/invoice.component';
import { LoginComponent } from './login/login.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { PaymentSuccessfullComponent } from './payment-successfull/payment-successfull.component';
import { ProfileComponent } from './profile/profile.component';
import { ReportGenrationComponent } from './report-genration/report-genration.component';
import { SignupComponent } from './signup/signup.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { UpdateUserComponent } from './update-user/update-user.component';
import { ViewCropsComponent } from './view-crops/view-crops.component';
import { ViewYourCropsComponent } from './view-your-crops/view-your-crops.component';

const routes: Routes = [
  {
    path:'', component:AppHomeComponent, pathMatch:'full'},
   {path:'Login', component:LoginComponent},
   {path:'Signup',component:SignupComponent},
   {path:'Viewcrops',component:ViewCropsComponent,canActivate:[AuthGuard]},
   {path:'CropOnSale',component:CropOnSaleComponent,canActivate:[AuthGuard]},
   {path:'ViewYourCropOnSale',component:ViewYourCropsComponent ,canActivate:[AuthGuard]},
   {path:'Updateprofile',component:UpdateUserComponent ,canActivate:[AuthGuard]},
   {path:'Farmerlanding',component:FarmerLandingPageComponent ,canActivate:[AuthGuard]},
   {path:'Dealerlanding',component:DealerLandingPageComponent ,canActivate:[AuthGuard]},
   {path:'Adminlanding',component:AdminLandingPageComponent,canActivate:[AuthGuard]},
   {path:'Invoice', component:InvoiceComponent,canActivate:[AuthGuard]},
   {path:'FarmerInvoice', component:FarmerInvoiceComponent,canActivate:[AuthGuard]},
   {path:'Adminlanding', component:AdminLandingPageComponent,canActivate:[AuthGuard]},
   {path:'ReportGenration', component:ReportGenrationComponent,canActivate:[AuthGuard]},
   {path:'UserStatus', component:ChangeUserStatusComponent,canActivate:[AuthGuard]},
   {path:'UserProfile', component:ProfileComponent,canActivate:[AuthGuard]},
   {path:'Features', component:FeaturesComponent,canActivate:[AuthGuard]},
   {path:'PaymentSuccess',component:PaymentSuccessfullComponent,canActivate:[AuthGuard]},
   {path:'Unauthorized',component:UnauthorizedComponent},
   {path:'**',component:PagenotfoundComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
