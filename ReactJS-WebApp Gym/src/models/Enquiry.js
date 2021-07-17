//data model of a Enquirey

export default class Enquiry {
    constructor(name, email, mobile, query, status, cseRemarks) {
        this.name = name;
        this.email = email;
        this.mobile = mobile;
        this.query = query;
        this.status = status;
        this.cseRemarks = cseRemarks;
    }

}