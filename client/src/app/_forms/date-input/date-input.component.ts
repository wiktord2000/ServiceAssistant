import { Component, Input, OnInit, Self } from '@angular/core';
import { NgControl } from '@angular/forms';

@Component({
  selector: 'app-date-input',
  templateUrl: './date-input.component.html',
  styleUrls: ['./date-input.component.css']
})
export class DateInputComponent implements OnInit {

  @Input() label: string;
  @Input() includeClearBtn: boolean = false;
  @Input() minDate?: Date;
  @Input() maxDate?: Date;
  
  constructor(@Self() public ngControl: NgControl) { 
    this.ngControl.valueAccessor = this; 
  }

  ngOnInit(): void {}
  
  clearDate(event){
    event.preventDefault();     // Prevent form submit
    this.ngControl.control.setValue(null);
  }



  // We don't have to use it
  writeValue(obj: any): void {}
  registerOnChange(fn: any): void {}
  registerOnTouched(fn: any): void {}
}
