const {expect} = require('chai');
const result = require('../task/task')();

describe('Sample tests', function() {
	describe('Solution template tests', function() {
		it('expect createApp to be a function with 4 parameters', function() {
			expect(result.createApp).to.exist;
			expect(result.createApp).to.be.a('function');
			expect(result.createApp).to.have.length(4);
		});
		it('expect createStore to be a function with 4 parameters', function() {
			expect(result.createStore).to.exist;
			expect(result.createStore).to.be.a('function');
			expect(result.createStore).to.have.length(4);
		});
		it('expect createDevice to be a function with 2 parameters', function() {
			expect(result.createDevice).to.exist;
			expect(result.createDevice).to.be.a('function');
			expect(result.createDevice).to.have.length(2);
		});
	});

	describe('Constructor tests', function() {
		describe('App tests', function() {
			it('expect createApp() with invalid name to throw', function() {
				expect(() => result.createApp(0, 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
				expect(() => result.createApp('+++', 'description', 0.1, 4)).to.throw();
			});

			it('expect createApp() with invalid description to throw', function() {
				expect(() => result.createApp('app', 0, 0.1, 4)).to.throw();
			});

			it('expect createApp() with invalid version to throw', function() {
				expect(() => result.createApp('app', 'description', 'version', 2)).to.throw();
				expect(() => result.createApp('app', 'description', -5, 4)).to.throw();
			});

			it('expect createApp() with non-number for rating to throw', function() {
				expect(() => result.createApp('app', 'description', 5, 'aresva mi')).to.throw();
				expect(() => result.createApp('app', 'description', 5, -2)).to.throw();
				expect(() => result.createApp('app', 'description', 5, 11)).to.throw();
			});

			it('expect App object to have valid properties', function() {
				const app = result.createApp('app', 'description', 1, 4);

				expect(app.name).to.equal('app');
				expect(app.description).to.equal('description');
				expect(app.version).to.equal(1);
				expect(app.rating).to.equal(4);
			});

			it('expect App object to have all of its methods', function() {
				const app = result.createApp('app', 'description', 1, 4);

				expect(app.release).to.be.a('function');
				expect(app.release).to.have.length(1);
			});
		});

		describe('Store tests', function() {
			it('expect createStore() with invalid name to throw', function() {
				expect(() => result.createStore(0, 'description', 0.1, 4)).to.throw();
				expect(() => result.createStore('', 'description', 0.1, 4)).to.throw();
				expect(() => result.createStore('1234567890123456789012345', 'description', 0.1, 4)).to.throw();
				expect(() => result.createStore('+++', 'description', 0.1, 4)).to.throw();
			});

			it('expect createStore() with invalid description to throw', function() {
				expect(() => result.createStore('app', 0, 0.1, 4)).to.throw();
			});

			it('expect createStore() with invalid version to throw', function() {
				expect(() => result.createStore('app', 'description', 'version', 2)).to.throw();
				expect(() => result.createStore('app', 'description', -5, 4)).to.throw();
			});

			it('expect createStore() with non-number for rating to throw', function() {
				expect(() => result.createStore('app', 'description', 5, 'aresva mi')).to.throw();
				expect(() => result.createStore('app', 'description', 5, -2)).to.throw();
				expect(() => result.createStore('app', 'description', 5, 11)).to.throw();
			});

			it('expect Store object to have valid properties', function() {
				const app = result.createStore('app', 'description', 1, 4);
				expect(app.name).to.equal('app');
				expect(app.description).to.equal('description');
				expect(app.version).to.equal(1);
				expect(app.rating).to.equal(4);

				expect(app.apps).to.be.eql([]);
			});

			it('expect Store object to have all of its methods', function() {
				const app = result.createStore('app', 'description', 1, 4);

				expect(app.release).to.be.a('function');
				expect(app.release).to.have.length(1);

				expect(app.uploadApp).to.be.a('function');
				expect(app.uploadApp).to.have.length(1);

				expect(app.takedownApp).to.be.a('function');
				expect(app.takedownApp).to.have.length(1);

				expect(app.search).to.be.a('function');
				expect(app.search).to.have.length(1);

				expect(app.listMostRecentApps).to.be.a('function');
				expect(app.listMostRecentApps).to.have.length(1);

				expect(app.listMostPopularApps).to.be.a('function');
				expect(app.listMostPopularApps).to.have.length(1);
			});
		});

		describe('Device tests', function() {
			it('expect createDevice() with invalid hostname to throw', function() {
				expect(() => result.createDevice(42, [])).to.throw();
				expect(() => result.createDevice('', [])).to.throw();
				expect(() => result.createDevice('123456789012345678901234567890123', [])).to.throw();
			});

			it('expect createDevice() with invalid app to throw', function() {
				expect(() => result.createDevice('pesho', 7)).to.throw();
				expect(() => result.createDevice('pesho', [7])).to.throw();
				expect(() => result.createDevice('pesho', ['gosho'])).to.throw();
				expect(() => result.createDevice('pesho', [{name: 'gosho'}])).to.throw();

				const app = result.createApp('app', 'description', 1, 1);
				expect(() => result.createDevice('pesho', [app, {name: 'gosho'}])).to.throw();
				expect(() => result.createDevice('pesho', [{name: 'gosho'}, app])).to.throw();
			});

			it('expect Device object to have valid properties', function() {
				const app = result.createDevice('Peshoo', []);

				expect(app.hostname).to.equal('Peshoo');

				expect(app.apps).to.be.eql([]);
			});

			it('expect Device object to have all of its methods', function() {
				const device = result.createDevice('Peshoo', []);

				expect(device.search).to.be.a('function');
				expect(device.search).to.have.length(1);

				expect(device.install).to.be.a('function');
				expect(device.install).to.have.length(1);

				expect(device.uninstall).to.be.a('function');
				expect(device.uninstall).to.have.length(1);

				expect(device.listInstalled).to.be.a('function');
				expect(device.listInstalled).to.have.length(0);

				expect(device.update).to.be.a('function');
				expect(device.update).to.have.length(0);
			});
		});
		describe('App Tests', function() {
			it('release() should succesfully change the version if valid', function() {
				const someApp = result.createApp('app', 'description', 1, 1);
				const otherApp = result.createApp('app', 'description', 10, 1);
				
				const actual = someApp.release(7);			
				expect(actual.version).to.equal(7);
				
				const actual1 = someApp.release(otherApp);			
				expect(actual.version).to.equal(10);
			});
			it('release() succesfully changes the description if its not undefined', function() {
				const someApp = result.createApp('app', 'description', 1, 1);
				const otherApp = result.createApp('app', 'description2', 5, 1);
				const otherApp2 = result.createApp('app', 'description23', 7, 1);
				
				const actual = someApp.release(otherApp);				
				expect(actual.description).to.equal('description2');
				
				const actual1 = someApp.release(otherApp2);				
				expect(actual1.description).to.equal('description23');
			});
			it('release() succesfully changes the rating if its not undefined', function() {
				const someApp = result.createApp('app', 'description', 0, 1);
				const otherApp = result.createApp('app', 'description2', 5, 1);
				const otherApp2 = result.createApp('app', 'description23', 7, 5);
				
				const actual = someApp.release(otherApp);				
				expect(actual.rating).to.equal(1);
				
				const actual1 = someApp.release(otherApp2);				
				expect(actual1.rating).to.equal(5);						
			});
			it('Throws error if lower or the same version is applyed', function() {
				const someApp = result.createApp('app', 'description', 5, 1);
				const otherApp = result.createApp('app', 'description2', 2, 1);
				const otherApp2 = result.createApp('app', 'description23', 5, 5);
				
				expect(() => someApp.release(otherApp)).to.throw();
				expect(() => someApp.release(otherApp2)).to.throw();
				expect(() => someApp.release(1)).to.throw();
			});
			it('release() throws error if new version is invalid or not specified', function() {
				const someApp = result.createApp('app', 'description', 1, 1);			
				
				expect(() => someApp.release()).to.throw();
				expect(() => someApp.release(-1)).to.throw();
				expect(() => someApp.release('1')).to.throw();
				expect(() => someApp.release(true)).to.throw();			
				expect(() => someApp.release(undefined)).to.throw();
			});
			it('release() throws error if new version has invalid description', function() {
				const someApp = result.createApp('app', 'description', 1, 1);	
				const invalidObj = {description: 1,version:1};
				const invalidObj1 = {description: {},version:1};
				const invalidObj2 = {description: [],version:1};
				
				expect(() => someApp.release(invalidObj)).to.throw();
				expect(() => someApp.release(invalidObj2)).to.throw();
				expect(() => someApp.release(invalidObj3)).to.throw();
			});
			it('release() throws error if new version has invalid rating', function() {
				const someApp = result.createApp('app', 'description', 1, 1);	
				const invalidObj = {rating: -1,version:1};
				const invalidObj1 = {rating: 11,version:1};
				const invalidObj2 = {rating: 'sajf',version:1};
				
				expect(() => someApp.release(invalidObj)).to.throw();
				expect(() => someApp.release(invalidObj2)).to.throw();
				expect(() => someApp.release(invalidObj3)).to.throw();
			});
			
		});
		describe('Store Tests', function() {
			it('uploadApp() Checks if app that doesnt exist in store will be added correctly', function() {
				const store = result.createStore('Store1', 'description', 1, 4);					
				const someApp = result.createApp('app', 'description', 0, 1);
				
				store.uploadApp(someApp);
									
				expect(store.apps[0].name).to.equal(someApp.name);
				expect(store.apps[0].description).to.equal(someApp.description);
				expect(store.apps[0].version).to.equal(someApp.version);
				expect(store.apps[0].rating).to.equal(someApp.rating);
			});
			it('uploadApp() If app with the same name does exist - updates the app to the newer version', function() {
				const store = result.createStore('Store1', 'description', 1, 4);					
				const someApp = result.createApp('app', 'description', 0, 1);
				const someApp1 = result.createApp('app', 'HAHAHA', 1, 9);
				
				store.apps.push(someApp);
				store.uploadApp(someApp1);
									
				expect(store.apps[0].name).to.equal(someApp.name);
				expect(store.apps[0].description).to.equal('HAHAHA');
				expect(store.apps[0].version).to.equal(1);
				expect(store.apps[0].rating).to.equal(9);
			});	
			it('uploadApp() throws if the new version is not bigger than the old one', function() {
				const store = result.createStore('Store1', 'description', 1, 4);
				const someApp = result.createApp('app', 'description', 3, 1);	
				const someApp1 = result.createApp('app', 'HAHAHA', 1, 9);
								
				store.apps.push(someApp);
				
				expect(() => store.uploadApp(someApp1)).to.throw();				
			});			
			it('uploadApp() to provide chaining', function() {
				const store = result.createStore('Store1', 'description', 1, 4);
				const someApp = result.createApp('app', 'description', 1, 1);	
				const someApp1 = result.createApp('app', 'HAHAHA', 2, 9);
				const someApp2 = result.createApp('app', 'HAHAHA', 3, 3);
																
				store.uploadApp(someApp).uploadApp(someApp1).uploadApp(someApp2);	
				const actual = store.apps[0];
				
				expect(store.apps[0].name).to.equal('app');
				expect(store.apps[0].description).to.equal('HAHAHA');
				expect(store.apps[0].version).to.equal(3);
				expect(store.apps[0].rating).to.equal(3);
			});				
		});
		
			it('takedownApp() should throw if an app with the given name does not exist', function() {
				const store = result.createStore('Store1', 'description', 1, 4);
				const someApp = result.createApp('app', 'description', 3, 1);
				
				expect(() => store.takedownApp(someApp)).to.throw();
			});
			it('takedownApp() should remove app from the store', function() {
				const store = result.createStore('Store1', 'description', 1, 4);
				const someApp = result.createApp('app', 'description', 3, 1);
				
				store.apps.push(someApp);
				store.takedownApp('app');
			
				expect(store.apps.length).to.equal(0);
			});
			it('takedownApp() to provide chaining', function() {
				const store = result.createStore('Store1', 'description', 1, 4);
				const someApp = result.createApp('app', 'description', 1, 1);	
				const someApp1 = result.createApp('appk', 'HAHAHA', 2, 9);
				const someApp2 = result.createApp('app1', 'HAHAHA', 3, 3);
																
				store.uploadApp(someApp).uploadApp(someApp1).uploadApp(someApp2)
				.takedownApp('app1').takedownApp('appk');
					
				const actual = store.apps[0];
				
				expect(store.apps[0].name).to.equal('app');
				expect(store.apps[0].description).to.equal('description');
				expect(store.apps[0].version).to.equal(1);
				expect(store.apps[0].rating).to.equal(1);
			});
		
			
				it('search() returns an array of apps containing pattern in their name', function() {
					const store = result.createStore('Store1', 'description', 1, 4);
				    const someApp = result.createApp('gosho', 'description', 1, 1);	
				    const someApp1 = result.createApp('pesho', 'uahamuaha', 2, 9);
				    const someApp2 = result.createApp('lambriana', 'HAHAHA', 3, 3);
					const pattern = 'sho';					
					
					store.uploadApp(someApp).uploadApp(someApp1).uploadApp(someApp2);
					const actual = store.search(pattern);
					
					expect(actual.length).to.equal(2);															
				});
				it('search()sorts apps lexicographically by name', function() {
					const store = result.createStore('Store1', 'description', 1, 4);
				    const someApp = result.createApp('gosho', 'description', 1, 1);	
				    const someApp1 = result.createApp('pesho', 'uahamuaha', 2, 9);
				    const someApp2 = result.createApp('lambriana', 'HAHAHA', 3, 3);
					const pattern = 'sho';					
					
					store.uploadApp(someApp).uploadApp(someApp1).uploadApp(someApp2);
					const actual = store.search(pattern);
					

					expect(actual[0].name).to.equal('gosho');
				    expect(actual[0].description).to.equal('description');
					expect(actual[0].version).to.equal(1);
					expect(actual[0].rating).to.equal(1);
					      
					expect(actual[1].name).to.equal('pesho');
					expect(actual[1].description).to.equal('uahamuaha');
					expect(actual[1].version).to.equal(2);
					expect(actual[1].rating).to.equal(9);				
				});
				it('search() should be case insensitive', function() {
					const store = result.createStore('Store1', 'description', 1, 4);
				    const someApp = result.createApp('GosHo', 'description', 1, 1);	
				    const someApp1 = result.createApp('PeSHO', 'uahamuaha', 2, 9);
				    const someApp2 = result.createApp('lambriana', 'HAHAHA', 3, 3);
					const pattern = 'SHO';					
					
					store.uploadApp(someApp).uploadApp(someApp1).uploadApp(someApp2);
					const actual = store.search(pattern);
					

					expect(actual[0].name).to.equal('GosHo');
				    expect(actual[0].description).to.equal('description');
					expect(actual[0].version).to.equal(1);
					expect(actual[0].rating).to.equal(1);
					      
					expect(actual[1].name).to.equal('PeSHO');
					expect(actual[1].description).to.equal('uahamuaha');
					expect(actual[1].version).to.equal(2);
					expect(actual[1].rating).to.equal(9);				
				});
			
			
				it('listMostRecentApps() count should work with optional value', function() {
					
					const store = result.createStore('Store1', 'description', 1, 4);
				    const someApp = result.createApp('app0', 'description', 1, 1);	
				    const someApp1 = result.createApp('app1', 'uahamuaha', 2, 9);
				    const someApp2 = result.createApp('app2', 'HAHAHA', 3, 3);
					const someApp3 = result.createApp('app3', 'description', 1, 1);	
				    const someApp4 = result.createApp('app4', 'uahamuaha', 2, 9);
				    const someApp5 = result.createApp('app5', 'HAHAHA', 3, 3);
					const someApp6 = result.createApp('app6', 'description', 1, 1);	
				    const someApp7 = result.createApp('app7', 'uahamuaha', 2, 9);
				    const someApp8 = result.createApp('app8', 'HAHAHA', 3, 3);
					const someApp9 = result.createApp('app9', 'description', 1, 1);	
				    const someApp10 = result.createApp('app10', 'uahamuaha', 2, 9);
				    const someApp11 = result.createApp('app11', 'HAHAHA', 3, 3);
					
					store.uploadApp(someApp).uploadApp(someApp1).uploadApp(someApp2)
					.uploadApp(someApp3).uploadApp(someApp4).uploadApp(someApp5)
					.uploadApp(someApp6).uploadApp(someApp7).uploadApp(someApp8)
					.uploadApp(someApp9).uploadApp(someApp10).uploadApp(someApp11);
					
					expect(store.listMostRecentApps().length).to.equal(10);	
				});
				it('listMostRecentApps() count should work with exact passed value', function() {
					
					const store = result.createStore('Store1', 'description', 1, 4);
				    const someApp = result.createApp('app0', 'description', 1, 1);	
				    const someApp1 = result.createApp('app1', 'uahamuaha', 2, 9);
				    const someApp2 = result.createApp('app2', 'HAHAHA', 3, 3);
					const someApp3 = result.createApp('app3', 'description', 1, 1);	
				    const someApp4 = result.createApp('app4', 'uahamuaha', 2, 9);
				    const someApp5 = result.createApp('app5', 'HAHAHA', 3, 3);
					const someApp6 = result.createApp('app6', 'description', 1, 1);	
				    const someApp7 = result.createApp('app7', 'uahamuaha', 2, 9);
				    const someApp8 = result.createApp('app8', 'HAHAHA', 3, 3);
					const someApp9 = result.createApp('app9', 'description', 1, 1);	
				    const someApp10 = result.createApp('app10', 'uahamuaha', 2, 9);
				    const someApp11 = result.createApp('app11', 'HAHAHA', 3, 3);
					
					store.uploadApp(someApp).uploadApp(someApp1).uploadApp(someApp2)
					.uploadApp(someApp3).uploadApp(someApp4).uploadApp(someApp5)
					.uploadApp(someApp6).uploadApp(someApp7).uploadApp(someApp8)
					.uploadApp(someApp9).uploadApp(someApp10).uploadApp(someApp11);
										
					expect(store.listMostRecentApps(5).length).to.equal(5);	
				});
				it('listMostRecentApps() returns an array of the count most recent apps sorted by time of upload - descending', function() {
					
					const store = result.createStore('Store1', 'description', 1, 4);
				    const someApp = result.createApp('app0', 'description', 1, 1);	
				    const someApp1 = result.createApp('app1', 'uahamuaha', 2, 9);
				    const someApp2 = result.createApp('app2', 'HAHAHA', 3, 3);
					const someApp3 = result.createApp('app3', 'description', 1, 1);	
				    const someApp4 = result.createApp('app4', 'uahamuaha', 2, 9);
				    const someApp5 = result.createApp('app5', 'HAHAHA', 3, 3);
					const someApp6 = result.createApp('app6', 'description', 1, 1);	
				    const someApp7 = result.createApp('app7', 'uahamuaha', 2, 9);
				    const someApp8 = result.createApp('app8', 'HAHAHA', 3, 3);
					const someApp9 = result.createApp('app9', 'description', 1, 1);	
				    const someApp10 = result.createApp('app10', 'uahamuaha', 2, 9);
				    const someApp11 = result.createApp('app11', 'HAHAHA', 3, 3);
					
					store.uploadApp(someApp).uploadApp(someApp1).uploadApp(someApp2)
					.uploadApp(someApp3).uploadApp(someApp4).uploadApp(someApp5)
					.uploadApp(someApp6).uploadApp(someApp7).uploadApp(someApp8)
					.uploadApp(someApp9).uploadApp(someApp10).uploadApp(someApp11);
					
					const actual = 	store.listMostRecentApps(3)			
					expect(actual.length).to.equal(3);	
					
					expect(actual[0].name).to.equal('app11');
				    expect(actual[0].description).to.equal('HAHAHA');
					expect(actual[0].version).to.equal(3);
					expect(actual[0].rating).to.equal(3);	
					
					expect(actual[1].name).to.equal('app10');
					expect(actual[1].description).to.equal('uahamuaha');
					expect(actual[1].version).to.equal(2);
					expect(actual[1].rating).to.equal(9);	
					
					expect(actual[2].name).to.equal('app9');
					expect(actual[2].description).to.equal('description');
					expect(actual[2].version).to.equal(1);
					expect(actual[2].rating).to.equal(1);						
				});
			
			
				it('listMostPopularApps() count should work with optional value', function() {
					
					const store = result.createStore('Store1', 'description', 1, 4);
				    const someApp = result.createApp('app0', 'description', 1, 1);	
				    const someApp1 = result.createApp('app1', 'uahamuaha', 2, 9);
				    const someApp2 = result.createApp('app2', 'HAHAHA', 3, 3);
					const someApp3 = result.createApp('app3', 'description', 1, 1);	
				    const someApp4 = result.createApp('app4', 'uahamuaha', 2, 9);
				    const someApp5 = result.createApp('app5', 'HAHAHA', 3, 3);
					const someApp6 = result.createApp('app6', 'description', 1, 1);	
				    const someApp7 = result.createApp('app7', 'uahamuaha', 2, 9);
				    const someApp8 = result.createApp('app8', 'HAHAHA', 3, 3);
					const someApp9 = result.createApp('app9', 'description', 1, 1);	
				    const someApp10 = result.createApp('app10', 'uahamuaha', 2, 9);
				    const someApp11 = result.createApp('app11', 'HAHAHA', 3, 3);
					
					store.uploadApp(someApp).uploadApp(someApp1).uploadApp(someApp2)
					.uploadApp(someApp3).uploadApp(someApp4).uploadApp(someApp5)
					.uploadApp(someApp6).uploadApp(someApp7).uploadApp(someApp8)
					.uploadApp(someApp9).uploadApp(someApp10).uploadApp(someApp11);
					
					expect(store.listMostRecentApps().length).to.equal(10);	
				});
				it('listMostPopularApps() count should work with exact passed value', function() {
					
					const store = result.createStore('Store1', 'description', 1, 4);
				    const someApp = result.createApp('app0', 'description', 1, 1);	
				    const someApp1 = result.createApp('app1', 'uahamuaha', 2, 9);
				    const someApp2 = result.createApp('app2', 'HAHAHA', 3, 3);
					const someApp3 = result.createApp('app3', 'description', 1, 1);	
				    const someApp4 = result.createApp('app4', 'uahamuaha', 2, 9);
				    const someApp5 = result.createApp('app5', 'HAHAHA', 3, 3);
					const someApp6 = result.createApp('app6', 'description', 1, 1);	
				    const someApp7 = result.createApp('app7', 'uahamuaha', 2, 9);
				    const someApp8 = result.createApp('app8', 'HAHAHA', 3, 3);
					const someApp9 = result.createApp('app9', 'description', 1, 1);	
				    const someApp10 = result.createApp('app10', 'uahamuaha', 2, 9);
				    const someApp11 = result.createApp('app11', 'HAHAHA', 3, 3);
					
					store.uploadApp(someApp).uploadApp(someApp1).uploadApp(someApp2)
					.uploadApp(someApp3).uploadApp(someApp4).uploadApp(someApp5)
					.uploadApp(someApp6).uploadApp(someApp7).uploadApp(someApp8)
					.uploadApp(someApp9).uploadApp(someApp10).uploadApp(someApp11);
										
					expect(store.listMostRecentApps(5).length).to.equal(5);	
				});
				it('listMostPopularApps() returns an array of the count most recent apps sorted by rating', function() {
					
					const store = result.createStore('Store1', 'description', 1, 4);
				    const someApp = result.createApp('app0', 'description', 2, 1);	
				    const someApp1 = result.createApp('app1', 'uahamuaha', 3, 9);
				    const someApp2 = result.createApp('app2', 'HAHAHA', 4, 3);
					const someApp3 = result.createApp('app3', 'description', 5, 1);	
				    const someApp4 = result.createApp('app4', 'uahamuaha', 6, 8);
				    const someApp5 = result.createApp('app5', 'HAHAHA', 7, 7);
					const someApp6 = result.createApp('app6', 'description', 8, 6);	
				    const someApp7 = result.createApp('app7', 'uahamuaha', 1, 5);
				    const someApp8 = result.createApp('app8', 'HAHAHA', 1, 4);
					const someApp9 = result.createApp('app9', 'description', 1, 1);	
				    const someApp10 = result.createApp('app10', 'uahamuaha', 2, 2);
				    const someApp11 = result.createApp('app11', 'HAHAHA', 3, 3);
					
					store.uploadApp(someApp).uploadApp(someApp1).uploadApp(someApp2)
					.uploadApp(someApp3).uploadApp(someApp4).uploadApp(someApp5)
					.uploadApp(someApp6).uploadApp(someApp7).uploadApp(someApp8)
					.uploadApp(someApp9).uploadApp(someApp10).uploadApp(someApp11);
					
					const actual = 	store.listMostPopularApps(3)			
					expect(actual.length).to.equal(3);	
					
					expect(actual[0].name).to.equal('app1');
				    expect(actual[0].description).to.equal('uahamuaha');
					expect(actual[0].version).to.equal(3);
					expect(actual[0].rating).to.equal(9);	
					
					expect(actual[1].name).to.equal('app4');
					expect(actual[1].description).to.equal('uahamuaha');
					expect(actual[1].version).to.equal(6);
					expect(actual[1].rating).to.equal(8);	
					
					expect(actual[2].name).to.equal('app5');
					expect(actual[2].description).to.equal('HAHAHA');
					expect(actual[2].version).to.equal(7);
					expect(actual[2].rating).to.equal(7);
					
				});
				it('listMostPopularApps() must sort items with same rating by time of upload', function() {
					
					const store = result.createStore('Store1', 'description', 1, 4);
				    const someApp = result.createApp('app0', 'description', 2, 1);	
				    const someApp1 = result.createApp('app1', 'uahamuaha', 3, 9);
				    const someApp2 = result.createApp('app2', 'HAHAHA', 4, 3);
					const someApp3 = result.createApp('app3', 'description', 5, 1);	
				    const someApp4 = result.createApp('app4', 'uahamuaha', 6, 9);
				    const someApp5 = result.createApp('app5', 'HAHAHA', 7, 9);
					const someApp6 = result.createApp('app6', 'description', 8, 6);	
				    const someApp7 = result.createApp('app7', 'uahamuaha', 1, 5);
				    const someApp8 = result.createApp('app8', 'HAHAHA', 1, 4);
					const someApp9 = result.createApp('app9', 'description', 1, 1);	
				    const someApp10 = result.createApp('app10', 'uahamuaha', 2, 2);
				    const someApp11 = result.createApp('app11', 'HAHAHA', 3, 3);
					
					store.uploadApp(someApp).uploadApp(someApp1).uploadApp(someApp2)
					.uploadApp(someApp3).uploadApp(someApp4).uploadApp(someApp5)
					.uploadApp(someApp6).uploadApp(someApp7).uploadApp(someApp8)
					.uploadApp(someApp9).uploadApp(someApp10).uploadApp(someApp11);
					
					const actual = 	store.listMostPopularApps(3)			
					expect(actual.length).to.equal(3);	
					
					expect(actual[0].name).to.equal('app4');									
					expect(actual[1].name).to.equal('app5');					
					expect(actual[2].name).to.equal('app1');													
				});				
			
			describe('Device tests', function() {
				it('search() should work correctly', function() {
					
					const someApp = result.createApp('aBa', 'description', 1, 1);	
				    const someApp1 = result.createApp('babaaaa', 'uahamuaha', 5, 9);	
					const store = result.createStore('Store1', 'description', 1, 4);
					store.uploadApp(someApp).uploadApp(someApp1);			
					const someApp2 = result.createApp('tHISABA', 'description', 2, 1);
				    const someApp3 = result.createApp('aBa', 'uahamuaha', 3, 9);	
					const store2 = result.createStore('Store1', 'description', 1, 4);
					store2.uploadApp(someApp2).uploadApp(someApp3);
					const store3 = result.createStore('Store1', 'description', 1, 4);
					const someApp22 = result.createApp('tHISABA', 'description', 13, 1);
					store3.uploadApp(someApp22);
					const device = result.createDevice('Device1',[store,store2,store3]);
					
					
					const actual = device.search('aBa')
					.map(x => x = {name: x.name, version: x.version});								
					
					expect(actual[0].name).to.equal('aBa');		
					expect(actual[0].version).to.equal(3);		
					expect(actual[1].name).to.equal('babaaaa');		
					expect(actual[1].version).to.equal(5);	
					expect(actual[2].name).to.equal('tHISABA');		
					expect(actual[2].version).to.equal(13);						
				});		
				it('install() does nothing if app is already installed', function() {
					
					const someApp = result.createApp('aBa', 'description', 1, 1);	
				    const someApp1 = result.createApp('babaaaa', 'uahamuaha', 5, 9);	
					const store = result.createStore('Store1', 'description', 1, 4);
					store.uploadApp(someApp).uploadApp(someApp1);			
					const someApp2 = result.createApp('tHISABA', 'description', 2, 1);
				    const someApp3 = result.createApp('aBa', 'uahamuaha', 3, 9);	
					const store2 = result.createStore('Store1', 'description', 1, 4);
					store2.uploadApp(someApp2).uploadApp(someApp3);
					const store3 = result.createStore('Store1', 'description', 1, 4);
					const someApp22 = result.createApp('tHISABA', 'description', 13, 1);
					store3.uploadApp(someApp22);
					const device = result.createDevice('Device1',[store,store2,store3]);
					
					device.apps.push(someApp);				
					device.install('aBa')
					
					expect(device.apps[3]).to.equal(someApp);
					expect(device.apps[3].name).to.equal('aBa');
					expect(device.apps[3].version).to.equal(1);
				});
				it('install() throws exeption if app name is not avaibable in stores', function() {
					
					const someApp = result.createApp('aBa', 'description', 1, 1);	
				    const someApp1 = result.createApp('babaaaa', 'uahamuaha', 5, 9);	
					const store = result.createStore('Store1', 'description', 1, 4);
					store.uploadApp(someApp).uploadApp(someApp1);			
					const someApp2 = result.createApp('tHISABA', 'description', 2, 1);
				    const someApp3 = result.createApp('aBa', 'uahamuaha', 3, 9);	
					const store2 = result.createStore('Store1', 'description', 1, 4);
					store2.uploadApp(someApp2).uploadApp(someApp3);
					const store3 = result.createStore('Store1', 'description', 1, 4);
					const someApp22 = result.createApp('tHISABA', 'description', 13, 1);
					store3.uploadApp(someApp22);
					const device = result.createDevice('Device1',[store,store2,store3]);
					
					device.apps.push(someApp);	
					
					expect(()=>device.install('asasgasgasgasg')).to.throw;
				});
				it('install() finds the most recent version of app', function() {
					
					const someApp = result.createApp('aBa', 'description', 1, 1);	
				    const someApp1 = result.createApp('babaaaa', 'uahamuaha', 5, 9);	
					const store = result.createStore('Store1', 'description', 1, 4);
					store.uploadApp(someApp).uploadApp(someApp1);			
					const someApp2 = result.createApp('tHISABA', 'description', 2, 1);
				    const someApp3 = result.createApp('aBa', 'uahamuaha', 3, 9);	
					const store2 = result.createStore('Store1', 'description', 1, 4);
					store2.uploadApp(someApp2).uploadApp(someApp3);
					const store3 = result.createStore('Store1', 'description', 1, 4);
					const someApp22 = result.createApp('tHISABA', 'description', 13, 1);
					store3.uploadApp(someApp22);
					const device = result.createDevice('Device1',[store,store2,store3]);	
					
					device.install('tHISABA');
					
					expect(device.apps[3].name).to.equal('tHISABA');
					expect(device.apps[3].version).to.equal(13);
				});
				it('install() should provide chaining', function() {
					
					const someApp = result.createApp('aBa', 'description', 1, 1);	
				    const someApp1 = result.createApp('babaaaa', 'uahamuaha', 5, 9);	
					const store = result.createStore('Store1', 'description', 1, 4);
					store.uploadApp(someApp).uploadApp(someApp1);			
					const someApp2 = result.createApp('tHISABA', 'description', 2, 1);
				    const someApp3 = result.createApp('aBa', 'uahamuaha', 3, 9);	
					const store2 = result.createStore('Store1', 'description', 1, 4);
					store2.uploadApp(someApp2).uploadApp(someApp3);
					const store3 = result.createStore('Store1', 'description', 1, 4);
					const someApp22 = result.createApp('tHISABA', 'description', 13, 1);
					store3.uploadApp(someApp22);
					const device = result.createDevice('Device1',[store,store2,store3]);	
					
					device.install('tHISABA').install('babaaaa');
					
					expect(device.apps[3].name).to.equal('tHISABA');
					expect(device.apps[3].version).to.equal(13);
					expect(device.apps[4].name).to.equal('babaaaa');
					expect(device.apps[4].version).to.equal(5);
				});
				it('uninstall() should provide chaining and work correctly', function() {
					
					const someApp = result.createApp('aBa', 'description', 1, 1);	
				    const someApp1 = result.createApp('babaaaa', 'uahamuaha', 5, 9);	
					const store = result.createStore('Store1', 'description', 1, 4);
					store.uploadApp(someApp).uploadApp(someApp1);			
					const someApp2 = result.createApp('tHISABA', 'description', 2, 1);
				    const someApp3 = result.createApp('aBa', 'uahamuaha', 3, 9);	
					const store2 = result.createStore('Store1', 'description', 1, 4);
					store2.uploadApp(someApp2).uploadApp(someApp3);
					const store3 = result.createStore('Store1', 'description', 1, 4);
					const someApp22 = result.createApp('tHISABA', 'description', 13, 1);
					store3.uploadApp(someApp22);
					const device = result.createDevice('Device1',[store,store2,store3]);	
					
					device.install('tHISABA').install('babaaaa');
					device.uninstall('tHISABA').uninstall('babaaaa');
					
					expect(device.apps.length).to.equal(3);
				});
				it('uninstall() should throw if no such app is installed', function() {
					
					const someApp = result.createApp('aBa', 'description', 1, 1);	
				    const someApp1 = result.createApp('babaaaa', 'uahamuaha', 5, 9);	
					const store = result.createStore('Store1', 'description', 1, 4);
					store.uploadApp(someApp).uploadApp(someApp1);			
					const someApp2 = result.createApp('tHISABA', 'description', 2, 1);
				    const someApp3 = result.createApp('aBa', 'uahamuaha', 3, 9);	
					const store2 = result.createStore('Store1', 'description', 1, 4);
					store2.uploadApp(someApp2).uploadApp(someApp3);
					const store3 = result.createStore('Store1', 'description', 1, 4);
					const someApp22 = result.createApp('tHISABA', 'description', 13, 1);
					store3.uploadApp(someApp22);
					const device = result.createDevice('Device1',[store,store2,store3]);	
					
					device.install('tHISABA').install('babaaaa');
					expect(()=>device.uninstall('pesagasg')).to.throw;
				});
				it('list apps should return apps sorted by name lexicographically', function() {
					
					const someApp = result.createApp('aBa', 'description', 1, 1);	
				    const someApp1 = result.createApp('babaaaa', 'uahamuaha', 5, 9);	
					const store = result.createStore('store1', 'description', 1, 4);
					store.uploadApp(someApp).uploadApp(someApp1);			
					const someApp2 = result.createApp('tHISABA', 'description', 2, 1);
				    const someApp3 = result.createApp('aBa', 'uahamuaha', 3, 9);	
					const store2 = result.createStore('store1', 'description', 1, 4);
					store2.uploadApp(someApp2).uploadApp(someApp3);
					const store3 = result.createStore('store1', 'description', 1, 4);
					const someApp22 = result.createApp('tHISABA', 'description', 13, 1);
					store3.uploadApp(someApp22);
					const device = result.createDevice('Device1',[store,store2,store3]);	
					
					device.install('tHISABA').install('babaaaa');
					
					const actual = device.listInstalled();
					
					expect(actual.length).to.equal(5);
					expect(actual[0].name).to.equal('babaaaa');
					expect(actual[1].name).to.equal('store1');
					expect(actual[2].name).to.equal('store1');
					expect(actual[3].name).to.equal('store1');
					expect(actual[4].name).to.equal('tHISABA');
				});
				it('update() should work correctly', function() {
					
					const someApp = result.createApp('aBa', 'description', 1, 1);	
				    const someApp1 = result.createApp('babaaaa', 'uahamuaha', 5, 9);	
					const store = result.createStore('store1', 'description', 1, 4);
					store.uploadApp(someApp).uploadApp(someApp1);			
					const someApp2 = result.createApp('tHISABA', 'description', 2, 1);
				    const someApp3 = result.createApp('aBa', 'uahamuaha', 3, 9);	
					const store2 = result.createStore('store1', 'description', 1, 4);
					store2.uploadApp(someApp2).uploadApp(someApp3);
					const store3 = result.createStore('store1', 'description', 1, 4);
					const someApp22 = result.createApp('tHISABA', 'description', 13, 1);
					store3.uploadApp(someApp22);
					const device = result.createDevice('Device1',[someApp2,someApp,store,store2,store3]);	
															
					device.update();
					
					expect(device.apps[1].name).to.equal('aBa');
					expect(device.apps[1].version).to.equal(3);
					expect(device.apps[0].name).to.equal('tHISABA');
					expect(device.apps[0].version).to.equal(13);
				});

				it('update() should provide chaining', function() {
					
					const someApp = result.createApp('aBa', 'description', 1, 1);	
				    const someApp1 = result.createApp('babaaaa', 'uahamuaha', 5, 9);	
					const store = result.createStore('store1', 'description', 1, 4);
					store.uploadApp(someApp).uploadApp(someApp1);			
					const someApp2 = result.createApp('tHISABA', 'description', 2, 1);
				    const someApp3 = result.createApp('aBa', 'uahamuaha', 3, 9);	
					const store2 = result.createStore('store1', 'description', 1, 4);
					store2.uploadApp(someApp2).uploadApp(someApp3);
					const store3 = result.createStore('store1', 'description', 1, 4);
					const someApp22 = result.createApp('tHISABA', 'description', 13, 1);
					store3.uploadApp(someApp22);
					const device = result.createDevice('Device1',[someApp2,someApp,store,store2,store3]);	
															
					device.update().update();
					
					expect(device.apps[1].name).to.equal('aBa');
					expect(device.apps[1].version).to.equal(3);
					expect(device.apps[0].name).to.equal('tHISABA');
					expect(device.apps[0].version).to.equal(13);
				});				
			});									
	});
});
