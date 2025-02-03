import logo from './logo.svg';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './App.css';
import CreateProduct from './CreateProduct';
import ProductList from './ProductList';
import Home from './Home';

function App() {
  return (
    <Router>
      <div className="app-container">
        <nav className="navbar">
          <ul className="nav-links">
            <li>
              <Link to="/" className="nav-link">Home</Link>
            </li>
            <li>
              <Link to="/create-product" className="nav-link">Criar Produtos</Link>
            </li>
            <li>
              <Link to="/product-list" className="nav-link">Lista de Produtos</Link>
            </li>
          </ul>
        </nav>

        <div className="content-container">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/create-product" element={<CreateProduct />} />
            <Route path="/create-product/:productId" element={<CreateProduct />} />
            <Route path="/product-list" element={<ProductList />} />
          </Routes>
        </div>
      </div>
    </Router>
  );
}

export default App;
  