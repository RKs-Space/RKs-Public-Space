// data model for program

export default class Program {
    constructor(programName, description, durationInMonth, price, discountRate, currentPrice, isActive) {
        this.programName = programName;
        this.description = description;
        this.durationInMonth = durationInMonth;
        this.price = price;
        this.discountRate = discountRate;
        this.currentPrice = currentPrice;
        this.isActive = isActive;
    }

}