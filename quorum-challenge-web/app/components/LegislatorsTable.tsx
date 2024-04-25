"use client";
import useSWR from "swr";
import React from "react";

const fetcher = (url: string | URL | Request) =>
  fetch(url).then((res) => res.json());

export default function LegislatorsTable() {
  const { data, error, isLoading } = useSWR(
    "https://localhost:7291/legislators",
    fetcher
  );

  if (error) return <div>Load failed: {error.message}</div>;
  if (isLoading) return <div>Loading...</div>;
  return (
    <table>
      <thead>
        <tr>
          <th>ID</th>
          <th>Legislator</th>
          <th>Supported bills</th>
          <th>Opposed bills</th>
        </tr>
      </thead>
      <tbody>
        {data.map((legislator: any) => (
          <tr>
            <td>{legislator.id}</td>
            <td>{legislator.name}</td>
            <td>{legislator.supportedBills}</td>
            <td>{legislator.opposedBills}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}
