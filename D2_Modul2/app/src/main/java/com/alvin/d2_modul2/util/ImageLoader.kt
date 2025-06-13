package com.alvin.d2_modul2.util

import android.app.Activity
import android.graphics.BitmapFactory
import android.widget.ImageView
import com.alvin.d2_modul2.constants.Constants
import java.net.HttpURLConnection
import java.net.URL
import kotlin.concurrent.thread

object ImageLoader {

    fun loadUserProfilePhoto(activity: Activity, imageView: ImageView, imageUri: String) {
        thread {
            val url = URL("${Constants.BASE_URL}/images/$imageUri")
            val connection = url.openConnection() as HttpURLConnection
            connection.doInput = true
            connection.connect()

            val inputStream = connection.inputStream
            val bitmap = BitmapFactory.decodeStream(inputStream)

            if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                activity.runOnUiThread {
                    imageView.setImageBitmap(bitmap)
                }
            }
        }
    }

}