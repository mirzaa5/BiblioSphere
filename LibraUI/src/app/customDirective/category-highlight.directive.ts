import { Directive,ElementRef,HostListener } from '@angular/core';

@Directive({
  selector: '[appCategoryHighlight]'
})
export class CategoryHighlightDirective {

  constructor( private divElement : ElementRef) { }

  @HostListener('mouseenter')
  onMouseEnter()
  {
    let innerText = this.divElement.nativeElement.innerText;
    if(innerText.includes("HORROR"))
    {
      this.divElement.nativeElement.innerText = "HORROR ( Only for Adults )";
    }
  }

  @HostListener('mouseleave')
  onMouseLeave()
  {
    this.divElement.nativeElement.innerText = this.divElement.nativeElement.innerText.replace('( Only for Adults )', '');
  }

  @HostListener('dblclick')
  onDoubleClick()
  {
    alert("Do you want to buy this book?")
  }

}
