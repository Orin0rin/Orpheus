import { AppComponent } from './app.component';
import { PodcastComponent } from './Podcast/podcast.component';
import { LoginComponent } from './Login/login.component';
import { SidebarComponent } from './Side_Menu/sidebar.component';
import { PodcastUserComponent } from './PodcastUser/podcastuser.component';
import { SignupComponent } from './signup/signup.component';
// import { AuthGuard } from './Login/auth.guard';
import { JwtInterceptor } from './Login/JwtInterceptor';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http'
import { AgGridModule } from 'ag-grid-angular';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule, Routes } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatIconModule} from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';


import 'bootstrap/dist/js/bootstrap';
import 'jquery-datetimepicker';
import 'bootstrap';
import 'bootstrap-datetime-picker';
import './Podcast/jquery.datetimepicker.d.ts';







const routes: Routes = [
  {path: 'sidebar' , component: SidebarComponent},
  {path: '' , component: LoginComponent},
  {path: 'podcast' , component: PodcastComponent },
  {path: 'podcastuser' , component:PodcastUserComponent},
  {path: 'login', component: LoginComponent },
  {path: 'signup', component: SignupComponent}
];



@NgModule({
 declarations: [
   AppComponent,
   PodcastComponent,
   LoginComponent,
   PodcastUserComponent,
   SignupComponent
 ],
 imports: [
   BrowserModule,
   HttpClientModule,
   AgGridModule,
   FormsModule,
   ReactiveFormsModule,
   BrowserAnimationsModule,
   NgbModule,
   MatFormFieldModule,
   MatInputModule,
   AppRoutingModule,
   RouterModule.forRoot(routes),
   MatCardModule,
   MatSidenavModule,
   MatIconModule,
   MatButtonModule,
   MatMenuModule,
   MatToolbarModule,
   MatListModule,
   MatExpansionModule,
   MatTooltipModule,
   MatDialogModule,
   MatSelectModule
 ],
 exports: [RouterModule],
 providers: [
  {
    provide: HTTP_INTERCEPTORS,
    useClass: JwtInterceptor,
    multi: true
  }
 ],
 bootstrap: [AppComponent]
})
export class AppModule { }
