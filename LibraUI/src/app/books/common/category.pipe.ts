import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'category'
})
export class CategoryPipe implements PipeTransform {

  transform(value: number, ...args: string[]): string {
    let result : string =""

    switch(value){
      case 0:
        result= "Fiction";break;
      case 1:
        result ="Non Fiction"; break;
      case 2:
        result = "Science"; break;
      case 3:
        result = "History"; break;
      case 4:
        result = "Biography"; break;
      case 5:
        result = "Poetry"; break;
      case 6:
        result = "Drama"; break;
      case 7:
        result = "Romance"; break;
      case 8:
        result = "Horror"; break;
      case 9:
        result = "Mystery"; break;
      case 10:
        result= "Thriller"; break;
      case 11:
        result = "Fantasy"; break;

    }
    if(args.length > 0 && args[0] === "uppercase" )
    {
      result = result.toUpperCase();
    }
    return result;
  }

}
