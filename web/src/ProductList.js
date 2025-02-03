import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './ProductList.css'; // Create a separate CSS file for custom styles

function ProductList() {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  const fetchProducts = async () => {
    try {
      const response = await axios.get('https://localhost:7211/api/product');
      setProducts(response.data);
      setLoading(false);
    } catch (error) {
      console.error('Error fetching products:', error);
      setError('Failed to fetch products. Please try again later.');
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchProducts();
  }, []);

  const handleEditClick = (productId) => {
    navigate(`/create-product/${productId}`);
  };

  const handleDeleteClick = async (productId) => {
    try {
      if (productId) {
        await axios.delete(`https://localhost:7211/api/product/${productId}`);
        fetchProducts();
      }
    } catch (error) {
      console.error('Error deleting product:', error);
      alert('Failed to delete product.');
    }
  };

  if (loading) {
    return <div className="loading-spinner">Carregando...</div>;
  }

  if (error) {
    return <div className="error-message">{error}</div>;
  }

  if (products.length === 0) {
    return <div className="no-products">Nenhum produto disponivel.</div>;
  }

  return (
    <div className="product-list-container">
      <h1 className="product-list-heading">Lista de produtos</h1>
      <table className="product-table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Nome</th>
            <th>Quantidade</th>
            <th>Preço</th>
            <th>Ativo</th>
            <th>Criado em</th>
            <th>Alterado em</th>
            <th>Ações</th>
          </tr>
        </thead>
        <tbody>
          {products.map((product) => (
            <tr key={product.id} className="product-row">
              <td>{product.id}</td>
              <td>{product.productName}</td>
              <td>{product.productQuantity}</td>
              <td>R$ {product.productPrice.toFixed(2)}</td>
              <td>{product.active ? 'Yes' : 'No'}</td>
              <td>{new Date(product.createdAt).toLocaleString()}</td>
              <td>{new Date(product.updatedAt).toLocaleString()}</td>
              <td>
                <button className="edit-btn" onClick={() => handleEditClick(product.id)}>✏️ Editar</button>
                <button className="delete-btn" onClick={() => handleDeleteClick(product.id)}>🗑️ Deletar</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ProductList;
