package com.alvin.d2_modul2.http

import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL

object HttpHandler {

    private const val BASE_URL = "http://localhost:5000/swagger"

    fun postRequest(endpoint: String, jsonObject: JSONObject): String {
        val url = URL("$BASE_URL/$endpoint")
        val connection = url.openConnection() as HttpURLConnection
        return try {
            connection.requestMethod = "POST"
            connection.setRequestProperty("Content-Type", "application/json")
            connection.doOutput = true

            val outputStream = connection.outputStream
            outputStream.write(jsonObject.toString().toByteArray())
            outputStream.flush()
            outputStream.close()

            if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                connection.inputStream.bufferedReader().use { it.readText() }
            } else {
                connection.errorStream?.bufferedReader().use { it?.readText() } ?: "Error: ${connection.responseCode}, ${connection.responseMessage}"
            }

        } catch (e: Exception) {
            "Error: $e"
        }
    }

    fun getRequest(endpoint: String): String {
        val url = URL("$BASE_URL/$endpoint")
        val connection = url.openConnection() as HttpURLConnection
        return try {
            connection.requestMethod = "GET"
            connection.setRequestProperty("Content-Type", "application/json")
            connection.doOutput = true

            if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                connection.inputStream.bufferedReader().use { it.readText() }
            } else {
                connection.errorStream?.bufferedReader().use { it?.readText() } ?: "Error: ${connection.responseCode}, ${connection.responseMessage}"
            }

        } catch (e: Exception) {
            "Error: $e"
        }
    }

}