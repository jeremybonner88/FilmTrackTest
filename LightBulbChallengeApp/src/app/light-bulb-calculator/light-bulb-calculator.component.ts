import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LightBulbCalculatorService } from '../services/light-bulb-calculator.service';

@Component({
  selector: 'app-light-bulb-calculator',
  templateUrl: './light-bulb-calculator.component.html',
  styleUrls: ['./light-bulb-calculator.component.css']
})
export class LightBulbCalculatorComponent implements OnInit {

  public numberOfPeople: number;
  public numberOfLightbulbs: number;

  constructor(public lightBulbCalculatorService: LightBulbCalculatorService) {
  }

  ngOnInit(): void {
    this.numberOfPeople = 0;
    this.numberOfLightbulbs = 0;
  }

  solveProblem() {
    this.lightBulbCalculatorService.solveLightProblem(this.numberOfPeople, this.numberOfLightbulbs).subscribe((data: any) => {
      this.lightBulbCalculatorService.lightBulbProblemResponses = data;
    });
  }
}
