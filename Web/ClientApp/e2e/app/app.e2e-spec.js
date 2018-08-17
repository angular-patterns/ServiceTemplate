"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var protractor_1 = require("protractor");
var SpecReporter = require('jasmine-spec-reporter').SpecReporter;
var options = require('../protractor-args').options;
var AppPage = /** @class */ (function () {
    function AppPage() {
    }
    AppPage.prototype.navigateTo = function () {
        return protractor_1.browser.get(options.virtualPath);
    };
    AppPage.prototype.getParagraphText = function () {
        return protractor_1.element(protractor_1.by.css('app-root>h1')).getText();
    };
    return AppPage;
}());
exports.AppPage = AppPage;
describe('App', function () {
    var page;
    beforeEach(function () {
        page = new AppPage();
    });
    it('should display hello world', function () {
        page.navigateTo();
        expect(page.getParagraphText()).toEqual('Hello World!');
    });
});
