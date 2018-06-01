import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Login from './components/Login';
import Home from './components/Home';
import FetchData from './components/FetchData';
import Counter from './components/Counter';

export const appRoutes = <Layout>
                          <Route path='/home' component={ Home }/>
                          <Route path='/counter' component={ Counter }/>
                          <Route path='/fetchdata/:startDateIndex?' component={ FetchData }/>
                      </Layout>;

export const login = <Route exact={true} path='/' component={ Login }/>;
