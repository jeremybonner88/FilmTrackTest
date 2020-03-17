import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LightBulbCalculatorComponent } from './light-bulb-calculator/light-bulb-calculator.component';
import { LightBulbCalculatorService } from './services/light-bulb-calculator.service'

@NgModule({
  declarations: [
    AppComponent,
    LightBulbCalculatorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [LightBulbCalculatorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
