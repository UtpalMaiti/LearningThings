# NgCompleteGuideUpdate

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 7.3.5.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).


A quick note: In the next lecture, I mention that it's important to add ModuleMapLoader to your app.server.ts file - if you're using Angular 9, this is NOT required anymore!

ng add @nguniversal/express-engine --clientProject ng-complete-guide-update

npm i @nguniversal/module-map-ngfactory-loader

 if (isPlatformBrowser(this.platformId)) {
      this.store.dispatch(new AuthActions.AutoLogin());
    }

npm run build:client-and-server-bundles && npm run compile:server //ng build:ssr

ng add @nestjs/ng-universal

Deploying Universal Apps
As mentioned in the previous lectures, you can't deploy an Angular Universal app to a static host (i.e. Firebase Hosting, AWS S3 etc will NOT work).
The reason for this is, that you're using Node.js to pre-render pages on the server and those Hosts don't support Node.js.
Hence you need a host that does - for example AWS ElasticBeanstalk or Heroku.
To these hosts, you need to upload your dist/ folder along with the package.json file. On the web server, you then have to ensure that npm install is executed, followed by npm serve:ssr.
That's it - your app is now up and running on a web server!
Here's an example how you could host Universal apps via Firebase Cloud Functions (NOT Firebase Hosting): https://www.udemy.com/the-complete-guide-to-angular-2/learn/lecture/15267340#questions/7482486

Angular Universal Gotchas
You typically use Angular Universal to pre-render Angular pages on the server. Once the app then runs on the client, it's a normal SPA again.

Server-side rendering (SSR) can make sense because of SEO considerations (crawler should see what your users see) or because you want to deliver a finished page to your users (rather than creating the page in the browser).

But that also has one important implication: You MUST NOT use any browser-only APIs like document.querySelector()  in your Angular code! 

Simply because it will execute on the server and there, such APIs are not available.

That's why, in this course, I recommended to use Angular features only: These features are safe to use because Angular will check if a certain API can be used before it uses 


<!-- https://github.com/angular/universal/blob/master/docs/gotchas.md -->

<!-- https://github.com/angular/universal#introduction -->